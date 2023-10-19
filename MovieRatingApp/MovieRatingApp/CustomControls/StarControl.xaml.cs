namespace MovieRatingApp.CustomControls;

public partial class StarControl : ContentView
{
    public int StarCount
    {
        get => (int)GetValue(StarCountProperty);
        set => SetValue(StarCountProperty, value);
    }

    public Color StarColor
    {
        get => (Color)GetValue(StarColorProperty);
        set => SetValue(StarColorProperty, value);
    }


    public static readonly BindableProperty StarCountProperty = BindableProperty.Create(
            nameof(StarCount),
            typeof(int),
            typeof(StarControl),
            propertyChanged: OnStarCountChanged,
            defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty StarColorProperty = BindableProperty.Create(
        nameof(StarColor),
        typeof(Color),
        typeof(StarControl),
        propertyChanged: OnButtonColorChanged);


    private static async void OnStarCountChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (StarControl)bindable;
        control.StarCount = (int)newValue;
        await Shell.Current.DisplayAlert(" ", " ", control.StarCount.ToString());
    }


    private static void OnButtonColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (StarControl)bindable;
        control.StarColor = (Color)newValue;
    }

    public StarControl()
    {
        InitializeComponent();
    }

    private void Buton_Clicked(object sender, EventArgs e)
    {
        StarCount = 1;
        StarColor = Colors.Gold;
    }

    private void Second_Clicked(object sender, EventArgs e)
    {
        StarCount = 2;
        StarColor = Colors.Gold;
    }

    private void Third_Clicked(object sender, EventArgs e)
    {
        StarCount = 3;
        StarColor = Colors.Gold;
    }

    private void Fourth_Clicked(object sender, EventArgs e)
    {
        StarCount = 4;
        StarColor = Colors.Gold;
    }

    private void Fifth_Clicked(object sender, EventArgs e)
    {
        StarCount = 5;
        StarColor = Colors.Gold;
    }
}