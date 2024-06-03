using System;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, European
    }

    public enum SwallowLoad
    {
        None, Coconut
    }

    public abstract class Swallow
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; }

        protected Swallow(SwallowType swallowType)
        {
            Type = swallowType;
        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public abstract double GetAirspeedVelocity();
    }

    public class AfricanSwallow : Swallow
    {
        public AfricanSwallow() : base(SwallowType.African) { }

        public override double GetAirspeedVelocity()
        {
            return Load switch
            {
                SwallowLoad.None => 22,
                SwallowLoad.Coconut => 18,
                _ => throw new InvalidOperationException(),
            };
        }
    }

    public class EuropeanSwallow : Swallow
    {
        public EuropeanSwallow() : base(SwallowType.European) { }

        public override double GetAirspeedVelocity()
        {
            return Load switch
            {
                SwallowLoad.None => 20,
                SwallowLoad.Coconut => 16,
                _ => throw new InvalidOperationException(),
            };
        }
    }

    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType)
        {
            return swallowType switch
            {
                SwallowType.African => new AfricanSwallow(),
                SwallowType.European => new EuropeanSwallow(),
                _ => throw new ArgumentException("Invalid swallow type"),
            };
        }
    }
}
