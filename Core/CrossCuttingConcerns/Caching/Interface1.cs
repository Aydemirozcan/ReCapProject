using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager                  //Bu aşağıdakiler zaten bizim kullanıcağımız Microsftun Cache sisteminde var ama biz başka zaman teknoloji değiştirebiliriz diye na bağlı kalmak istemiyoruz.Kendi metodlarımızı yazıyoruz.
    {
        T Get<T>(string key);   //Biz T döndürcez.herşey olabilir,Listede olabilir.İçindeki T de hangi tipde tutuğumuzdur.
        object Get(string key);
        void Add(string key, object value, int duration);  //object herşeyin base i dir.//Bu cashe de ne kadar duracağını belirtmek için duration var.
        bool IsAdd(string key);    //Cache de var mı varsa ordan gönder yoksa veritabanından al cache de ekle.
        void Remove(string key);        //Cache den uçurma.bir key verirsin ve onu o keyden bulup gidip siler.//Ama bizim parametrik metodlarımızın parametre kısmları farklı olabiliyor(int,string vs..)bunun için bir pattern yazıyoruz.
        void RemoveByPattern(string pattern);   //başı sonu önemli değil içinde get olanalrı uçur(sil) gibi,yada içnde category olanalrı sil gibi

    }
}
