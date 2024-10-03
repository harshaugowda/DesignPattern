using System;
namespace DesignPaatterns
{
	public abstract class DiscountService
	{
		public abstract int GetDiscount { get; }

        public override string ToString()
        {
            return GetType().Name;
        }
    }

    public class CountryDiscountService : DiscountService
    {
        private readonly string CountryCode;
        public CountryDiscountService(string countryCode)
        {
            CountryCode = countryCode;
        }

        public override int GetDiscount
        {
            get
            {
                switch (CountryCode)
                {
                    case "Ind":
                        return 20;
                    default:
                        return 10;
                }
            }
        }
    }

    public class CodeDiscountService : DiscountService
    {
        private readonly Guid Code;

        public CodeDiscountService(Guid code)
        {
            Code = code;
        }
        public override int GetDiscount => 15;
    }

    public abstract class DiscountFactory
    {
        public abstract DiscountService CreateDiscountFactory();
    }

    public class CountryDiscountFactory : DiscountFactory
    {
        private readonly string CountryCode;
        public CountryDiscountFactory(string countryCode)
        {
            CountryCode = countryCode;
        }
        public override DiscountService CreateDiscountFactory()
        {
            return new CountryDiscountService(CountryCode);
        }
    }

    public class CodeDiscountFactory : DiscountFactory
    {
        private readonly Guid Code;

        public CodeDiscountFactory(Guid code)
        {
            Code = code;
        }

        public override DiscountService CreateDiscountFactory()
        {
            return new CodeDiscountService(Code);
        }
    }
}

