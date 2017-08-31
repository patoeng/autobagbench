using XS156Client35.Models;

namespace AutoBagBench
{
    public delegate void IntParamEvent(int data);

    public delegate void ErrorEvent(Error data);
    public delegate void StringFunctionDelegate(string data);
    public delegate void StringDelegate(string data);
    public delegate void IntDelegate(int data);
    public delegate void BarcodeOrderNumberDelegate(string data, string ordernumber);
    public delegate void TrackingBagDelegate(TrackingDataBag track);
    public delegate void NoParamDelegate();
}
