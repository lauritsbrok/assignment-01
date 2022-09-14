namespace Assignment1;

public static class Iterators
{
    public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items) {
        foreach(var list in items){
            foreach(var s in list){
                yield return s;
            }
        }
    }

    public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate) {
        foreach(var item in items){
            if(predicate(item)){
                yield return item;
            }
        }
    }
}