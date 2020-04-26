using OnlineSinavSistemi.Bll.Abstract;
using OnlineSinavSistemi.Core.Concrete;
using OnlineSinavSistemi.Dal.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineSinavSistemi.Bll.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        OnlineSinavSistemiContext context;
        public UnitOfWork(OnlineSinavSistemiContext _context)
        {
            context = _context;
        }
        //ENCAPSULATION
        //fields
        IBransService brans;
        IDersService ders;
        IKullaniciCevapService kullaniciCevap;
        IKullaniciService kullanici;
        IKullaniciSinavService kullaniciSinav;
        IKursDersService kursDers;
        IKursMerkeziService kursMerkezi;
        IKursService kurs;
        ISikayetService sikayet;
        IRolService rol;
        ISinavService sinav;
        ISinavSoruService sinavSoru;
        ISoruService soru;
        IYorumService yorum;

        //properties
        public IBransService Brans => brans ?? (brans=new BransService(new BransRepository(context)));

        public IDersService Ders => ders?? (ders=new DersService(new DersRepository(context)));

        public IKullaniciCevapService KullaniciCevap => kullaniciCevap ?? (kullaniciCevap=new KullaniciCevapService(new KullaniciCevapRepository(context)));

        public IKullaniciService Kullanici => kullanici ?? (kullanici=new KullaniciService(new KullaniciRepository(context)));

        public IKullaniciSinavService KullaniciSinav => kullaniciSinav ?? (kullaniciSinav=new KullaniciSinavService(new KullaniciSinavRepository(context)));

        public IKursDersService KursDers => kursDers?? (kursDers = new KursDersService(new KursDersRepository(context)));
        public IKursService Kurs => kurs ?? (kurs = new KursService(new KursRepository(context)));


        public IKursMerkeziService KursMerkezi => kursMerkezi ?? (kursMerkezi=new KursMerkeziService(new KursMerkeziRepository(context)));

        public IRolService Rol => rol?? (rol=new RolService(new RolRepository(context)));

        public ISikayetService Sikayet => sikayet?? (sikayet=new SikayetService(new SikayetRepository(context)));

        public ISinavService Sinav => sinav?? (sinav = new SinavService(new SinavRepository(context)));

        public ISinavSoruService SinavSoru => sinavSoru ?? (sinavSoru = new SinavSoruService(new SinavSoruRepository(context)));

        public ISoruService Soru => soru?? (soru =new SoruService(new SoruRepository(context)));

        public IYorumService Yorum => yorum?? (yorum=new YorumService(new YorumRepository(context)));

        public ResultMessage<int> SaveChanges()
        {
            using (var dbTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    int result = context.SaveChanges();

                    dbTransaction.Commit();
                    return new ResultMessage<int> { BasariliMi = true, Data=result, Mesaj = "İşlem başarılı." };
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    return new ResultMessage<int> { BasariliMi = false, Data=-1, Mesaj = ex.Message };

                }
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
