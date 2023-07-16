using System;

class Store
{
    List<Item> _products;
    ShoppingCart _cart;
}

class ShoppingCart
{
    Dictionary<Item, int> _contents;
    double _total;
}