XFormsListViewCellReusingBug
============================

Demonstrates a cell reusing bug in Xamarin.Forms on Android. To reproduce:

1. build and deploy the code to an Android device
2. the list should fill the whole screen
3. scroll down until you reach the bottom
4. click button to add new entry at beginning of list
5. scroll down again

 --> last entry should be "Item 0", but is something like "Item 12"
