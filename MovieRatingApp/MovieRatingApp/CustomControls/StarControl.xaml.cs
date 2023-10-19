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


    private static void OnStarCountChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (StarControl)bindable;
        control.StarCount = (int)newValue;
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

    private void First_Clicked(object sender, EventArgs e)
    {
        StarCount = 1;
        FillButtons(sender);
    }

    private void Second_Clicked(object sender, EventArgs e)
    {
        StarCount = 2;
        FillButtons(sender);
    }

    private void Third_Clicked(object sender, EventArgs e)
    {
        StarCount = 3;
        FillButtons(sender);
    }

    private void Fourth_Clicked(object sender, EventArgs e)
    {
        StarCount = 4;
        FillButtons(sender);
    }

    private void Fifth_Clicked(object sender, EventArgs e)
    {
        StarCount = 5;
        FillButtons(sender);
    }

    private void FillButtons(object sender)
    {
        for (int i = 1; i <= StarCount; i++)
        {
            Button button = (Button)sender;
            button = (Button)button.FindByName(i.ToString());
            button.BackgroundColor = StarColor;
            button.BindingContext = BackgroundColor;
        }

        for (int i = 1; i <= 5 - StarCount; i++) 
        {
            Button button = (Button)sender;
            button = (Button)button.FindByName((StarCount + i).ToString());
            button.BackgroundColor = Colors.DarkGray;
            button.BindingContext = BackgroundColor;
        }
    }
}