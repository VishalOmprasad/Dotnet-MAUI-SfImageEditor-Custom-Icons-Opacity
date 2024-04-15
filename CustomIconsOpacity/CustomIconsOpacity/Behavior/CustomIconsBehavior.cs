using Syncfusion.Maui.ImageEditor;

namespace CustomIconsOpacity;

internal class CustomIconsBehavior : Behavior<ContentPage>
{
    /// <summary>
    /// image editor initialize
    /// </summary>
    private SfImageEditor? imageEditor;

    protected override void OnAttachedTo(ContentPage bindable)
    {
        base.OnAttachedTo(bindable);
        this.imageEditor = bindable.FindByName<SfImageEditor>("imageEditor");

        if (imageEditor != null)
        {            
            ImageEditorToolbar headerToolbar = imageEditor.Toolbars[0];
            ImageEditorToolbarGroupItem saveGroup = (ImageEditorToolbarGroupItem)headerToolbar.ToolbarItems[0];
            ImageEditorToolbarItem? undoItem = saveGroup.Items.FirstOrDefault(i => i.Name == "Undo");
            ImageEditorToolbarItem? redoItem = saveGroup.Items.FirstOrDefault(i => i.Name == "Redo");
            
            if (undoItem != null) 
            {
                Image undoImage = new Image();
                undoImage.Source = ImageSource.FromFile("undoicon.png");
                undoItem.View = undoImage;
                undoImage.PropertyChanged += (sender, e) =>
                {
                    if (e.PropertyName == VisualElement.IsEnabledProperty.PropertyName)
                    {
                        double opacity = undoImage.IsEnabled ? 1.0 : 0.5;
                        undoImage.Opacity = opacity;
                    }
                };
            }
            

            if (redoItem != null)
            {
                Image redoImage = new Image();
                redoImage.Source = ImageSource.FromFile("redoicon.png");
                redoItem.View = redoImage;
                redoImage.PropertyChanged += (sender, e) =>
                {
                    if (e.PropertyName == VisualElement.IsEnabledProperty.PropertyName)
                    {
                        double opacity = redoImage.IsEnabled ? 1.0 : 0.5;
                        redoImage.Opacity = opacity;
                    }
                };
            }
        }
    }

    protected override void OnDetachingFrom(ContentPage bindable)
    {
        base.OnDetachingFrom(bindable);

        if (this.imageEditor != null)
        {
            this.imageEditor = null;
        }
    }
}