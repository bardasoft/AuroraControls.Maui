﻿namespace AuroraControls;

public class StyledInputLayout : ContentView, IUnderlayDrawable
{
    public static readonly Dictionary<Type, StyledContentTypeRegistration> StyledInputLayoutContentRegistrations =
        new()
        {
            [typeof(IPicker)] =
                StyledContentTypeRegistration.Build<IPicker>(
                    nameof(IPicker.SelectedIndex),
                    view => view.SelectedIndex >= 0,
                    false),
            [typeof(IDatePicker)] = StyledContentTypeRegistration.Default,
            [typeof(ITimePicker)] = StyledContentTypeRegistration.Default,
            [typeof(Editor)] =
                StyledContentTypeRegistration.Build<Editor>(
                    nameof(Editor.Text),
                    view => !string.IsNullOrEmpty(view.Text),
                    true),
            [typeof(InputView)] =
                StyledContentTypeRegistration.Build<InputView>(
                    nameof(InputView.Text),
                    view => !string.IsNullOrEmpty(view.Text),
                    false),
        };

    public bool AlignPlaceholderToTop => false;

    public static readonly BindableProperty InternalMarginProperty = UnderlayDrawableElement.InternalMarginProperty;

    public Thickness InternalMargin
    {
        get { return (Thickness)GetValue(InternalMarginProperty); }
        set { SetValue(InternalMarginProperty, value); }
    }

    public static readonly BindableProperty BorderStyleProperty = UnderlayDrawableElement.BorderStyleProperty;

    public ContainerBorderStyle BorderStyle
    {
        get { return (ContainerBorderStyle)GetValue(BorderStyleProperty); }
        set { SetValue(BorderStyleProperty, value); }
    }

    public static readonly BindableProperty ActiveColorProperty = UnderlayDrawableElement.ActiveColorProperty;

    public Color ActiveColor
    {
        get { return (Color)GetValue(ActiveColorProperty); }
        set { SetValue(ActiveColorProperty, value); }
    }

    public static readonly BindableProperty InactiveColorProperty = UnderlayDrawableElement.InactiveColorProperty;

    public Color InactiveColor
    {
        get { return (Color)GetValue(InactiveColorProperty); }
        set { SetValue(InactiveColorProperty, value); }
    }

    public static readonly BindableProperty DisabledColorProperty = UnderlayDrawableElement.DisabledColorProperty;

    public Color DisabledColor
    {
        get { return (Color)GetValue(DisabledColorProperty); }
        set { SetValue(DisabledColorProperty, value); }
    }

    public static readonly BindableProperty IsErrorProperty = UnderlayDrawableElement.IsErrorProperty;

    public bool IsError
    {
        get { return (bool)GetValue(IsErrorProperty); }
        set { SetValue(IsErrorProperty, value); }
    }

    public static readonly BindableProperty ErrorTextProperty = UnderlayDrawableElement.ErrorTextProperty;

    public string ErrorText
    {
        get { return (string)GetValue(ErrorTextProperty); }
        set { SetValue(ErrorTextProperty, value); }
    }

    public static readonly BindableProperty ErrorColorProperty = UnderlayDrawableElement.ErrorColorProperty;

    public Color ErrorColor
    {
        get { return (Color)GetValue(ErrorColorProperty); }
        set { SetValue(ErrorColorProperty, value); }
    }

    public static readonly BindableProperty ActivePlaceholderFontSizeProperty = UnderlayDrawableElement.ActivePlaceholderFontSizeProperty;

    public float ActivePlaceholderFontSize
    {
        get { return (float)GetValue(ActivePlaceholderFontSizeProperty); }
        set { SetValue(ActivePlaceholderFontSizeProperty, value); }
    }

    public static readonly BindableProperty BorderSizeProperty = UnderlayDrawableElement.BorderSizeProperty;

    public float BorderSize
    {
        get { return (float)GetValue(BorderSizeProperty); }
        set { SetValue(BorderSizeProperty, value); }
    }

    public static readonly BindableProperty CornerRadiusProperty = UnderlayDrawableElement.CornerRadiusProperty;

    public float CornerRadius
    {
        get { return (float)GetValue(CornerRadiusProperty); }
        set { SetValue(CornerRadiusProperty, value); }
    }

    public static readonly BindableProperty AlwaysShowPlaceholderProperty = UnderlayDrawableElement.AlwaysShowPlaceholderProperty;

    public bool AlwaysShowPlaceholder
    {
        get { return (bool)GetValue(AlwaysShowPlaceholderProperty); }
        set { SetValue(AlwaysShowPlaceholderProperty, value); }
    }

    public static readonly BindableProperty FocusAnimationDurationProperty = UnderlayDrawableElement.FocusAnimationDurationProperty;

    public uint FocusAnimationDuration
    {
        get { return (uint)GetValue(FocusAnimationDurationProperty); }
        set { SetValue(FocusAnimationDurationProperty, value); }
    }

    public static readonly BindableProperty FocusAnimationPercentageProperty = UnderlayDrawableElement.FocusAnimationPercentageProperty;

    public double FocusAnimationPercentage
    {
        get { return (double)GetValue(FocusAnimationPercentageProperty); }
        set { SetValue(FocusAnimationPercentageProperty, value); }
    }

    public static readonly BindableProperty HasValueAnimationPercentageProperty = UnderlayDrawableElement.HasValueAnimationPercentageProperty;

    public double HasValueAnimationPercentage
    {
        get { return (double)GetValue(HasValueAnimationPercentageProperty); }
        set { SetValue(HasValueAnimationPercentageProperty, value); }
    }

    public static readonly BindableProperty PlaceholderOffsetProperty = HavePlaceholderElement.PlaceholderOffsetProperty;

    public Point PlaceholderOffset
    {
        get { return (Point)GetValue(PlaceholderOffsetProperty); }
        set { SetValue(PlaceholderOffsetProperty, value); }
    }

    public static readonly BindableProperty PlaceholderProperty = HavePlaceholderElement.PlaceholderProperty;

    public string Placeholder
    {
        get { return (string)GetValue(PlaceholderProperty); }
        set { SetValue(PlaceholderProperty, value); }
    }

    public static readonly BindableProperty PlaceholderColorProperty = HavePlaceholderElement.PlaceholderColorProperty;

    public bool InheritPlaceholderFromContent
    {
        get { return (bool)GetValue(InheritPlaceholderFromContentProperty); }
        set { SetValue(InheritPlaceholderFromContentProperty, value); }
    }

    public static readonly BindableProperty InheritPlaceholderFromContentProperty = HavePlaceholderElement.InheritPlaceholderFromContentProperty;

    public Color PlaceholderColor
    {
        get { return (Color)GetValue(PlaceholderColorProperty); }
        set { SetValue(PlaceholderColorProperty, value); }
    }

    public static readonly BindableProperty FontSizeProperty = HavePlaceholderElement.FontSizeProperty;

    public double FontSize
    {
        get { return (double)GetValue(FontSizeProperty); }
        set { SetValue(FontSizeProperty, value); }
    }

    public static readonly BindableProperty CommandProperty = UnderlayDrawableElement.CommandProperty;

    public ICommand Command
    {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }

    public static readonly BindableProperty CommandParameterProperty = UnderlayDrawableElement.CommandParameterProperty;

    public object CommandParameter
    {
        get { return (object)GetValue(CommandParameterProperty); }
        set { SetValue(CommandParameterProperty, value); }
    }
}

public record StyledContentTypeRegistration(string ValueChangeProperty, Func<IView, bool> HasValue, bool AlignPlaceholderToTop)
{
    public static readonly StyledContentTypeRegistration Default =
        new(string.Empty, _ => true, false);

    public static StyledContentTypeRegistration Build<TView>(string valueChangeProperty, Func<TView, bool> hasValue,
        bool alignPlaceholderToTop)
    where TView : IView
    {
        return new StyledContentTypeRegistration(valueChangeProperty, viewIn => viewIn is TView view && hasValue(view), alignPlaceholderToTop);
    }
}
