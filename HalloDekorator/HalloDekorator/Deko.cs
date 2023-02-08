namespace HalloDekorator
{
    internal interface IComponent
    {
        decimal Preis { get; }
        string Beschreibung { get; }
    }

    class Pizza : IComponent //ConcreteComponent
    {
        public decimal Preis => 6.5m;

        public string Beschreibung => "Pizza";
    }

    class Brot : IComponent //ConcreteComponent
    {
        public decimal Preis => 3.2m;

        public string Beschreibung => "Brot";
    }

    abstract class Deko : IComponent
    {
        protected IComponent _parent;

        protected Deko(IComponent parent)
        {
            _parent = parent;
        }

        public abstract decimal Preis { get; }

        public abstract string Beschreibung { get; }
    }

    class Käse : Deko
    {
        public Käse(IComponent parent) : base(parent)
        { }

        public override decimal Preis => _parent.Preis + 1.5m;

        public override string Beschreibung => _parent.Beschreibung + " Käse";
    }

    class Salami : Deko
    {
        public Salami(IComponent parent) : base(parent)
        { }

        public override decimal Preis => _parent.Preis + 2.7m;

        public override string Beschreibung => _parent.Beschreibung + " Salami";
    }
}
