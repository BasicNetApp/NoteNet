﻿using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows;

namespace NoteNet.UI.Controls
{
    public class BindableRichTextBox : RichTextBox
    {
        public TextTrimming TextTrimming { get; set; }

        public static readonly DependencyProperty DocumentProperty =
            DependencyProperty.Register("Document", typeof(FlowDocument),
            typeof(BindableRichTextBox), new FrameworkPropertyMetadata
            (null, new PropertyChangedCallback(OnDocumentChanged)));

        public new FlowDocument Document
        {
            get
            {
                return (FlowDocument)this.GetValue(DocumentProperty);
            }

            set
            {
                this.SetValue(DocumentProperty, value);
            }
        }

        public static void OnDocumentChanged(DependencyObject obj,
            DependencyPropertyChangedEventArgs args)
        {
            RichTextBox rtb = (RichTextBox)obj;
            rtb.Document = (FlowDocument)args.NewValue;

            TextRange tr = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            tr.ApplyPropertyValue(TextElement.ForegroundProperty, Application.Current.Resources["ForegroundColor"]);
        }
    }
}
