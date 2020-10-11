namespace NiceOne.Domain.Common.Models
{
    public class ModelConstants
    {
        public class Common
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 20;
            public const int MinDescriptionLength = 2;
            public const int MaxDescriptionLength = 1000;
            public const int MinEmailLength = 3;
            public const int MaxEmailLength = 50;
            public const int MaxUrlLength = 2048;
            public const int Zero = 0;
        }

        public class Feedback
        {
            public const int MinTextLength = 2;
            public const int MaxTextLength = 2000;
            public const int MinRatingValue = 1;
            public const int MaxRatingValue = 5;
        }

    }
}
