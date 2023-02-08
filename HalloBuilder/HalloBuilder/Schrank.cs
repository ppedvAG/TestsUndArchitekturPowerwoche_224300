namespace HalloBuilder
{
    internal class Schrank
    {
        public int AnzTüren { get; private set; }
        public int AnzBöden { get; private set; }
        public string Farbe { get; private set; }
        public bool Kleiderstange { get; private set; }
        public bool Metallschienen { get; private set; }
        public Oberfläche Oberfläche { get; private set; }
        private Schrank()
        { }

        internal class Builder
        {
            private Schrank _schrank = new Schrank();

            public Builder SetBöden(int anzahlBöden)
            {
                if (anzahlBöden < 0 || anzahlBöden > 6)
                    throw new ArgumentException("Zuviele oder zuweniger Böden!");

                _schrank.AnzBöden = anzahlBöden;
                return this;
            }

            public Builder SetTüren(int anzahlTüren)
            {
                if (anzahlTüren < 2 || anzahlTüren > 7)
                    throw new ArgumentException("Zuviele oder zuweniger Türen!");

                _schrank.AnzTüren = anzahlTüren;
                return this;
            }

            public Builder SetFarbe(string farbe)
            {
                if (_schrank.Oberfläche != Oberfläche.Lackiert)
                    throw new ArgumentException("Schrank muss lackiert sein um eine Farbe zu haben");
                if (string.IsNullOrWhiteSpace(farbe))
                    throw new ArgumentException("Farbe darf nicht leer sein");
                
                _schrank.Farbe = farbe;
                return this;
            }

            public Builder SetObfläche(Oberfläche oberfläche)
            {
                _schrank.Oberfläche = oberfläche;
                return this;
            }

            public Schrank Create()
            {
                return _schrank;
            }
        }
    }

    public enum Oberfläche
    {
        Unbehandelt,
        Gewachst,
        Lackiert
    }
}
