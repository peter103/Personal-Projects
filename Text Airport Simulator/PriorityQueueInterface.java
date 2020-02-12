
public interface PriorityQueueInterface<T extends Comparable<T>> 
{
    public void add(T newEntry);
    public T remove();
    public T peek();
    public boolean isEmpty();
    public int getSize();
    public void clear();
}
