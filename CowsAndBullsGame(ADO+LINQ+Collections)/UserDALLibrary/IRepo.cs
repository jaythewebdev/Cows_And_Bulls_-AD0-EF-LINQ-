namespace UserDALLibrary
{
   

        public interface IRepo<T, K>
        {
            T Add(T item);

        }
    
}