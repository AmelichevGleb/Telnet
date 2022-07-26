using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.IO.Ports;

namespace telnet
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string port;
        private string speed;
        private string countBit;
        private string control;
        private string countStopBit;

        public MainWindow()
        {          
            InitializeComponent();      
            AddPortInCB();
        }
        private void AddPortInCB()
        {
            string[] ports = SerialPort.GetPortNames();
            int count = 0;
            foreach (string port in ports)
            {
                CB_Port.Items.Insert(count,port);
                count++;
            }
        }
        private void CB_Port_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            port = null; 
            port = CB_Port.SelectedItem.ToString();
        }
        private void CB_Speed_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            speed = null;
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            speed = selectedItem.Content.ToString();   
        }
        private void CB_CountBit_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            countBit = null;
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            countBit = selectedItem.Content.ToString();
        }
        private void CB_Control_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            control = null; 
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            control = selectedItem.Content.ToString();
        }
        private void CB_CountStopBit_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            countStopBit = null;
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            countStopBit = selectedItem.Content.ToString();
        }

        private void OpenXml()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("state.xml");
            foreach (XmlNode node in xDoc.DocumentElement)
            {
                string st = node["Speed"].InnerText;
                string st1 = node["CountBit"].InnerText;
                string st2 = node["Control"].InnerText;
                string st24 = node["CountStopBit"].InnerText;
                //CB_Speed.SetValue(st1);
            }
        }
        private void CreateXML()
        {
            XDocument xmlFile = new XDocument();
            XElement AttributeState = new XElement("State");
            XElement speedAtr = new XElement("Speed", speed);
            XElement countBitAtr = new XElement("CountBit", countBit);
            XElement controlAtr = new XElement("Control", control);
            XElement countStopBitAtr = new XElement("CountStopBit", countStopBit);
            AttributeState.Add(speedAtr);
            AttributeState.Add(countBitAtr);
            AttributeState.Add(controlAtr);
            AttributeState.Add(countStopBitAtr);
            XElement stateTel = new XElement("State");
            stateTel.Add(AttributeState);
            xmlFile.Add(stateTel);
            xmlFile.Save("state.xml");
            MessageBox.Show("Data saved");
        }


        private string ReturnStringComboBox(ComboBox _comboBox)
        {
            if (_comboBox.SelectedIndex == -1)
            { return null; }
            else
            {
                return _comboBox.SelectedItem.ToString();
            }
        }
        
        private DeviceSettings device = new DeviceSettings();
        private void Bt_Save_Click(object sender, RoutedEventArgs e)
        {
            if (ReturnStringComboBox(CB_Port) != null) {  device.Port = port; }
            if (ReturnStringComboBox(CB_Speed) != null) { device.Speed = speed; }
            if (ReturnStringComboBox(CB_CountBit) != null) { device.CountBit = countBit; }
            if (ReturnStringComboBox(CB_Control) != null) { device.Control = control; }
            if (ReturnStringComboBox(CB_CountStopBit) != null) { device.CountStopBit = countStopBit; }
            CreateXML();
            Console.WriteLine($"Port: {device.Port}  Speed: { device.Speed} countBit: { device.CountBit} control: { device.Control } countStopBit: { device.CountStopBit} ");
        }
  
    }
}
