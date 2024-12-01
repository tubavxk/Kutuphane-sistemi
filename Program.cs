using System;

public class kitap
{
    public string başlık { get; set; }
    public string yazar { get; set; }
    public string ISBN { get; set; }
    public bool IsAvailable { get; set; }

    public kitap(string başlık, string yazar, string isbn)
    {
        başlık = başlık;
        yazar = yazar;
        ISBN = isbn;
        IsAvailable = true;
    }
}

public class kullanıcı
{
    public string isim { get; set; }
    public string kullanıcıkimliği { get; set; }
    public List<kitap> Ödünçalınankitaplar { get; set; }

    public kullanıcı (string isim, string kullanıcıkimliği)
    {
        isim = isim;
        kullanıcıkimliği = kullanıcıkimliği;
        Ödünçalınankitaplar = new List<kitap>();
    }

    public void BorrowBook(kitap book)
    {
        if (book.IsAvailable)
        {
            Ödünçalınankitaplar.Add(book);
            book.IsAvailable = false;
            Console.WriteLine($"{isim} başarıyla '{book.başlık}' kitabını ödünç aldı.");
        }
        else
        {
            Console.WriteLine($"'{book.başlık}' kitabı şu an ödünç verilemez.");
        }
    }

    public void ReturnBook(kitap book)
    {
        if (Ödünçalınankitaplar.Contains(book))
        {
            Ödünçalınankitaplar.Remove(book);
            book.IsAvailable = true;
            Console.WriteLine($"{isim} başarıyla '{book.başlık}' kitabını geri verdi.");
        }
        else
        {
            Console.WriteLine($"{book.başlık} kitabını ödünç almadınız.");
        }
    }
}

public class LibrarySystem
{
    public List<kitap> kitaplar { get; set; }
    public List<kullanıcı> Users { get; set; }

    public LibrarySystem()
    {
        kitaplar = new List<kitap>();
        Users = new List<kullanıcı>();
    }

    public void AddBook(kitap book)
    {
        kitaplar.Add(book);
        Console.WriteLine($"'{book.başlık}' kitabı sisteme eklendi.");
    }

    public void RegisterUser(kullanıcı user)
    {
        Users.Add(user);
        Console.WriteLine($"Kullanıcı {user.isim} sisteme kaydedildi.");
    }

    public void ShowBooks()
    {
        Console.WriteLine("Kitaplar Listesi:");
        foreach (var book in kitaplar)
        {
            Console.WriteLine($"- {book.başlık} ({book.yazar}) - {(book.IsAvailable ? "Mevcut" : "Ödünç Alındı")}");
        }
    }
}

class Program
{
    static void Main()
    {
     
        LibrarySystem library = new LibrarySystem();

        library.AddBook(new kitap("C# Programlamaya Giriş", "John Doe", "123456789"));
        library.AddBook(new kitap("Algoritmalar", "Jane Smith", "987654321"));

        
        kullanıcı user1 = new kullanıcı(" Tuğba Azsoy" , "1029");
        kullanıcı user2 = new kullanıcı("Duygu Azsoy", "1215");

        library.RegisterUser(user1);
        library.RegisterUser(user2);

        user1.BorrowBook(library.kitaplar[0]);
        user2.BorrowBook(library.kitaplar[1]);
        library.ShowBooks();
        user1.ReturnBook(library.kitaplar[0]);
        library.ShowBooks();
    }
}

