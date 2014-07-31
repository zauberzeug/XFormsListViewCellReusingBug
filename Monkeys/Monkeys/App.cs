using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Monkeys
{
    public static class App
    {
        public class Entry
        {
            public string Title { get; set; }
        }

        static ObservableCollection<Entry> entries { get; set; }

        public static Page GetMainPage()
        {
            entries = new ObservableCollection<Entry>();
            for (var i = 0; i < 15; i++)
                entries.Insert(0, new Entry { Title = "Item " + i + " (start)" });

            var list = new ListView {
                ItemsSource = entries,
                ItemTemplate = new DataTemplate(() => {
                    var title = new Label();
                    title.SetBinding(Label.TextProperty, "Title");

                    return new ViewCell {
                        View = new StackLayout { 
                            Padding = 10, 
                            Children = { title }
                        }
                    };
                }),
            };

            var button = new Button { Text = "Click" };
            button.Clicked += delegate {
                entries.Insert(0, new Entry { Title = "Item " + entries.Count + " (click)" });
            };

            return new ContentPage {
                Content = new StackLayout {
                    Children = { list, button }
                }
            };
        }
    }
}
