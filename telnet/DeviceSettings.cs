using System;

public class DeviceSettings
{
    private string port = null;
    private string speed = null;
    private string countBit = null;
    private string control = null;
    private string countStopBit = null;

    public string Port
    {
        get { return port; }
        set { port = value; }
    } 

    public string Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    public string CountBit
    {
        get { return countBit; }
        set { countBit = value; }
    }
    public string Control
    {
        get { return control; }
        set { control = value; }
    }
    public string CountStopBit
    {
        get { return countStopBit; }
        set { countStopBit = value; }
    }
}