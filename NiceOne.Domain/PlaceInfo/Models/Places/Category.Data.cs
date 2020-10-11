namespace NiceOne.Domain.PlaceInfo.Models.Places
{
    using NiceOne.Domain.Common;
    using System;
    using System.Collections.Generic;

    public class CategoryData : IInitialData
    {
        public Type EntityType => typeof(Category);

        public IEnumerable<object> GetData()
           => new List<Category>
               {
                    new Category("Eat", "Favorite places to eat: restaurants, fast food places, pubs offering some delicious snacks, gourme shops, etc.", "https://i.pinimg.com/564x/96/31/72/963172b7bc598ee3f293bad7b80efcb8.jpg"),
                    new Category("Have fun", "All places where fun and laugh are!", "https://pluspng.com/img-png/children-having-fun-at-school-png-kids-having-fun-at-school-png-pluspng-com-720-kids-having-fun-720.png"),
                    new Category("Learn", "I really learned something here!", "https://www.pngkey.com/png/full/332-3321371_learning-clipart-discovery-animations-png-discovery-learning.png"),
                    new Category("Have a drink", "Search where to have a drink or two!", "https://i1.wp.com/blog.hellofresh.co.uk/wp-content/uploads/2015/12/Xmas_Cocktails_2015_DEFINITIV1.png?resize=800%2C500"),
                    new Category("Do your hair", "Best places to improve your look!", "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcS5Y4eCLP8GJvkqCiPflhJzbXwIqnPDZotbang-O3FaE0_l3tVL&usqp=CAU"),
                    new Category("Relax", "Perfect place to relax!", "https://pngriver.com/wp-content/uploads/2018/04/Download-Relax-Transparent-PNG.png")
               };
    }
}
