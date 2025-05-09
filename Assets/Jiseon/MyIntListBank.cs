using AirFishLab.ScrollingList;
using AirFishLab.ScrollingList.ContentManagement;

// The bank for providing the content for the box to display
// Must be inherit from the class BaseListBank
public class MyIntListBank : BaseListBank
{
    // The content to be passed to the list box
    // must inherit from the class `IListContent`.
    public class Content : IListContent
    {
        public string Value;  
    }

    private readonly string[] _contents = {
        "입춘", "우수", "경칩", "춘분", "청명", "곡우", "입하", "소만", "망종", "하지",
        "소서", "대서", "입추", "처서", "백로", "추분", "한로", "상강", "입동",
        "소설", "대설", "동지", "소한", "대한"
    };

    // This function will be invoked by the `CircularScrollingList`
    // to get the content to display.
    public override IListContent GetListContent(int index)
    {
        var content = new Content
        {
            Value = _contents[index]
        };
        return content;
    }

    public override int GetContentCount()
    {
        return _contents.Length;
    }
}
