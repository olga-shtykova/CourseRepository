namespace Module7
{
    // Класс для объекта “Книга”
    class BookClass
    {
        public string Name;
        public string Author;
    }

    // Класс для объекта “Коллекция книг”
    class BookCollection
    {
        // Закрытое поле, хранящее книги в виде массива
        private BookClass[] collection;

        // Конструктор с добавлением массива книг
        public BookCollection(BookClass[] collection)
        {
            this.collection = collection;
        }

        // Индексатор по массиву
        public BookClass this[int index]
        {
            get
            {
                // Проверяем, чтобы индекс был в диапазоне для массива
                if (index >= 0 && index < collection.Length)
                {
                    return collection[index];
                }
                else
                {
                    return null;
                }
            }

            private set
            {
                // Проверяем, чтобы индекс был в диапазоне для массива
                if (index >= 0 && index < collection.Length)
                {
                    collection[index] = value;
                }
            }
        }

        public BookClass this[string name]
        {
            get
            {
                for (int i = 0; i < collection.Length; i++)
                {
                    if (collection[i].Name == name)
                    {
                        return collection[i];
                    }
                }

                return null;
            }
        }
    }
}
