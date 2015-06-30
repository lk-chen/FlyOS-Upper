using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 姿态显示
{
    public partial class Form1 : Form
    {
        private TextBox _dataTextBox;
        private string _receivedText, _receivedTextBuffer;
        private PictureBox _dataFigure;
        private bool _reading;
        private int _dataNum;
        private List<Color> _colors;
        private List<float> _figurePoints;
        private Queue<List<float>> _figurePointsQueue;
        private int _pointsQueueCapacity;
        private int _figureStep;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = drawTimer.Enabled = false;

            WindowState=FormWindowState.Maximized;
            lblUARTName.Left = 30;
            lblUARTName.Top = 30;
            cmbUARTName.Left = lblUARTName.Right;
            cmbUARTName.Top = lblUARTName.Top;
            lblUARTBaud.Left = cmbUARTName.Right;
            lblUARTBaud.Top = cmbUARTName.Top;
            cmbUARTBaud.Left = lblUARTBaud.Right;
            cmbUARTBaud.Top = lblUARTBaud.Top;
            btnConnect.Left = cmbUARTBaud.Right + 30;
            btnConnect.Top = cmbUARTBaud.Top;
            btnDataClear.Left = btnConnect.Right + 30;
            btnDataClear.Top = btnConnect.Top;

            lblNewLine.Left = lblUARTName.Left;
            lblNewLine.Top = lblUARTName.Bottom + 20;
            cmbNewLine.Left = lblNewLine.Right;
            cmbNewLine.Top = lblNewLine.Top;
            cmbNewLine.SelectedIndex = 0;
            serialPort1.NewLine = "\r\n";
            ckbDTR.Left = cmbNewLine.Right + 20;
            ckbDTR.Top = cmbNewLine.Top;
            ckbRTS.Left = ckbDTR.Right;
            ckbRTS.Top = ckbDTR.Top;
            lblDataNum.Left = btnConnect.Left;
            lblDataNum.Top = ckbRTS.Top;
            cmbDataNum.Left = lblDataNum.Right;
            cmbDataNum.Top = lblDataNum.Top;
            cmbDataNum.SelectedIndex = 3;

            tbcShowData.Left = lblUARTName.Left;
            tbcShowData.Top = lblNewLine.Bottom + 20;
            tbcShowData.Width = Width - 360;
            tbcShowData.Height = 400;
            tbcShowData.SelectedIndexChanged += tbcShowData_SelectedIndexChanged;

            var ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            cmbUARTName.Items.AddRange(ports);

            _dataTextBox = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
            };
            _dataTextBox.TextChanged += text_TextChanged;
            tbpText.Controls.Add(_dataTextBox);

            _dataFigure = new PictureBox
            {
                Dock = DockStyle.Fill,
            };
            tbpFigure.Controls.Add(_dataFigure);

            lblState.Left = tbcShowData.Left;
            lblState.Top = tbcShowData.Bottom + 30;

            _receivedText = "";
            _receivedTextBuffer = "";
            _reading = false;

            _colors = new List<Color>(10);
            _colors.Add(Color.White);
            _colors.Add(Color.Red);
            _colors.Add(Color.Green);
            _colors.Add(Color.Blue);
            _colors.Add(Color.Black);
            _colors.Add(Color.Brown);
            _colors.Add(Color.GreenYellow);
            _colors.Add(Color.DarkOrange);
            _colors.Add(Color.Yellow);
            _colors.Add(Color.DeepPink);

            _figureStep = 5;
            _pointsQueueCapacity = _dataFigure.Width/_figureStep;
            _figurePointsQueue = new Queue<List<float>>(_pointsQueueCapacity);
        }

        private void figureClear()
        {
            var g = _dataFigure.CreateGraphics();
            g.Clear(_colors[0]);

            if (_figurePointsQueue.Count == 0) return;
            var pointsList = new List<float>[_figurePointsQueue.Count];
            _figurePointsQueue.CopyTo(pointsList, 0);

            int Xref = 0;
            int Yref = _dataFigure.Height / 2;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //消除锯齿
            for (int iPoint = 0; iPoint < _dataNum; iPoint++)
            {
                // Draw one line each time
                var former = new Point(Xref, (int) (pointsList[0][iPoint] + Yref));
                var pen = new Pen(_colors[iPoint + 1], 2);
                for (int iDraw = 0; iDraw < _figurePointsQueue.Count; iDraw++)
                {
                    // Draw one pixel each time
                    var current = new Point(iDraw * _figureStep, (int)(pointsList[iDraw][iPoint]) + Yref);
                    g.DrawLine(pen, former, current);

                    former = current;
                }
            }
        }

        private void serialPort_Initialize()
        {
            serialPort1 = new SerialPort
            {
                Parity = Parity.None,
                StopBits = StopBits.One,
                DataBits = 8,
                Handshake = Handshake.None,
                DtrEnable = ckbDTR.Checked,
                RtsEnable = ckbRTS.Checked,
                ReceivedBytesThreshold = 1,
            };
            serialPort1.DataReceived += (serialPort1_DataReceived);
        }

        private void text_TextChanged(object sender, EventArgs e)
        {
            _dataTextBox.ScrollToCaret();
        }

        private void cmbNewLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNewLine.SelectedIndex == cmbNewLine.Items.IndexOf("\\r\\n"))
                serialPort1.NewLine = "\r\n";
            if (cmbNewLine.SelectedIndex == cmbNewLine.Items.IndexOf("\\n"))
                serialPort1.NewLine = "\n";
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                btnConnect.Text = "连接";
                cmbDataNum.Enabled = true;
                timer1.Enabled = drawTimer.Enabled = false;
            }
            else
            {
                if (cmbUARTName.SelectedIndex >= 0 && cmbUARTBaud.SelectedIndex >= 0)
                {
                    serialPort_Initialize();
                    serialPort1.PortName = cmbUARTName.Text;
                    serialPort1.BaudRate = int.Parse(cmbUARTBaud.Text);
                    try
                    {
                        serialPort1.Open();
                        btnConnect.Text = "关闭";
                        cmbDataNum.Enabled = false;
                        figureClear();
                        timer1.Enabled = drawTimer.Enabled = true;
                    }
                    catch (Exception exception)
                    {
                        serialPort_Initialize();
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!serialPort1.IsOpen)
                return;

            try
            {
                _receivedTextBuffer += serialPort1.ReadExisting();
            }
            catch (Exception){}

            #region parse data

            Regex regex = new Regex(serialPort1.NewLine);
            bool parseSuccess = false;
            if (regex.IsMatch(_receivedTextBuffer))
            {
                // get at least one new line
                var lines = regex.Split(_receivedTextBuffer);
                foreach (var line in lines)
                {
                    // analyze every line
                    Regex reg = new Regex(@"\s");
                    var token = reg.Split(line);
                    // get tokens of each line
                    if (token.Length == _dataNum)
                    {
                        // token number is right
                        List<float> temp = new List<float>(_dataNum);
                        for (int i = 0; i < _dataNum; i++)
                        {
                            // parse each token into data
                            try
                            {
                                temp.Add(float.Parse(token[i]));
                            }
                            catch (Exception)
                            {
                                // something wrong, drop this line
                                break;
                            }
                        }
                        _figurePoints = new List<float>(temp);
                        parseSuccess = true;
                    }
                }
            }
            if (parseSuccess)
            {
                if (_reading)
                    return;
                _reading = true;
                _receivedText += _receivedTextBuffer;
                _reading = false;

                _receivedTextBuffer = "";
            }

            #endregion
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_reading || _receivedText.Length == 0)
                return;
            _reading = true;
            try
            {
                _dataTextBox.AppendText(_receivedText);
                _receivedText = "";
            }
            catch (Exception){}
            finally
            {
                _reading = false;
            }
        }

        private void ckbDTR_CheckedChanged(object sender, EventArgs e)
        {
            serialPort1.DtrEnable = ckbDTR.Checked;
        }

        private void ckbRTS_CheckedChanged(object sender, EventArgs e)
        {
            serialPort1.RtsEnable = ckbRTS.Checked;
        }

        private void btnTextClear_Click(object sender, EventArgs e)
        {
            _receivedText = "";
            _dataTextBox.Text = "";

            _figurePointsQueue.Clear();
            figureClear();
        }

        private void cmbDataNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dataNum = cmbDataNum.SelectedIndex;
            _figurePoints = new List<float>(_dataNum);
            for (int i = 0; i < _dataNum; i++)
            {
                _figurePoints.Add(0);
            }
        }

        private void drawTimer_Tick(object sender, EventArgs e)
        {
            if (_figurePoints.Count != _dataNum)
                return;
            var _currentPoints = _figurePoints;
            if (!serialPort1.IsOpen)
            {
                _figurePointsQueue.Clear();
                return;
            }
            if (_figurePointsQueue.Count >= _pointsQueueCapacity)
            {
                for (int i = 0; i < _pointsQueueCapacity * 2 / 3; i++)
                    _figurePointsQueue.Dequeue();
                figureClear();
            }
            if (_figurePointsQueue.Count > 0)
            {
                int Yref = _dataFigure.Height/2;

                var g = _dataFigure.CreateGraphics();
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //消除锯齿
                for (int iPoint = 0; iPoint < _dataNum; iPoint++)
                {
                    // Draw one line each time
                    var pen = new Pen(_colors[iPoint + 1], 2);
                    var former = new Point((_figurePointsQueue.Count - 1)*_figureStep,
                        (int) (_figurePointsQueue.Last()[iPoint] + Yref));
                    var current = new Point((_figurePointsQueue.Count)*_figureStep,
                        (int) (_currentPoints[iPoint] + Yref));
                    g.DrawLine(pen, former, current);
                }
            }
            _figurePointsQueue.Enqueue(_currentPoints);
        }

        private void tbcShowData_SelectedIndexChanged(object sender, EventArgs s)
        {
            if (tbcShowData.SelectedIndex == 0)
            {
                _dataFigure.Refresh();
                figureClear();
            }
        }
    }
}
