using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

// bug:
// 1) scroll down
// 2) click button to add new entry at beginning of list
// 3) scroll down again
// --> last entry should be "Item 0", but is something like "Item 12"

namespace Monkeys
{
    public class App
    {
        public class Entry
        {
            public string Title { get; set; }
        }

        static ObservableCollection<Entry> entries { get; set; }

        public static Page GetMainPage()
        {
            entries = new ObservableCollection<Entry>();
            // use enough elements to fill the screen to reproduce the bug
            for (var i = 0; i < 15; i++)
                entries.Insert(0, new Entry { Title = "Item " + i.ToString() + " (start)" });

            var list = new ListView {
                ItemsSource = entries,
                ItemTemplate = new DataTemplate(() => {
                    var title = new Label();
                    title.SetBinding(Label.TextProperty, "Title");

                    return new ViewCell {
                        // works when using "View = title"
                        View = new StackLayout { 
                            Padding = 10, 
                            Children = { title }
                        }
                    };
                }),
            };

            var button = new Button { Text = "Click" };
            button.Clicked += delegate {
                entries.Insert(0, new Entry { Title = "Item " + entries.Count.ToString() + " (click)" });
            };

            return new ContentPage {
                Content = new StackLayout {
                    Children = { list, button }
                }
            };
        }
    }
}
