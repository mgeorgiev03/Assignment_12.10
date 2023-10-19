namespace MovieRatingApp.CustomControls;

public partial class StarButton : ContentView
{
    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(
        nameof(ImageSource),
        typeof(FileImageSource),
        typeof(StarButton),
        default(FileImageSource));

    public FileImageSource ImageSource
    {
        get => (FileImageSource)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }


    public StarButton()
	{
		InitializeComponent();
	}
}