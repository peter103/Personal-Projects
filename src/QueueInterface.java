public interface QueueInterface<T>
{
    public void add(T newEntry);
    
    public T remove();
    
    public T peek();

    public int getSize();

    public boolean isEmpty();

    public void clear();
}
