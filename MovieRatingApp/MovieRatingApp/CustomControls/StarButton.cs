namespace MovieRatingApp.CustomControls
{
    public class StarButton : GraphicsView
    {
        public Color ButtonColor
        {
            get => (Color)GetValue(ButtonColorProperty);
            set => SetValue(ButtonColorProperty, value);
        }

        public string Image
        {
            get => (string)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);

        }


        public static BindableProperty ButtonColorProperty = BindableProperty.Create(
            nameof(ButtonColor),
            typeof(Color),
            typeof(StarButton),
            propertyChanged: OnButtonColorChanged);

        public static BindableProperty ImageProperty = BindableProperty.Create(
            nameof(Image),
            typeof(string),
            typeof(StarButton),
            propertyChanged: OnImageChanged);


        static void OnButtonColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (StarButton)bindable;
            var buttonColor = control.ButtonColor;
            if (control.Drawable is CustomButtonDrawable thisDrawable)
                thisDrawable.ButtonColor = buttonColor;

            control.Invalidate();
        }

        static void OnImageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (StarButton)bindable;
            var image = control.Image;
            if (control.Drawable is CustomButtonDrawable thisDrawable)
                thisDrawable.Image = image;
            control.Invalidate();

        }
    }
}
