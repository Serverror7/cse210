using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Runtime.InteropServices;

public class Mana
{
    private int _whiteCost;
    private int _blueCost;
    private int _blackCost;
    private int _redCost;
    private int _greenCost;
    private int _colorlessCost;
    private int _genericCost = 0;
    private bool _XCost = false;
    public void SetCost(int w, int u, int b, int r, int g, int c)
    {
        _whiteCost = w;
        _blueCost = u;
        _blackCost = b;
        _redCost = r;
        _greenCost = g;
        _colorlessCost = c;
    }
    public void SetWhiteCost(int cost)
    {
        _whiteCost = cost;
    }
    public void SetBlueCost(int cost)
    {
        _blueCost = cost;
    }
    public void SetBlackCost(int cost)
    {
        _blackCost = cost;
    }
    public void SetRedCost(int cost)
    {
        _redCost = cost;
    }
    public void SetGreenCost(int cost)
    {
        _greenCost = cost;
    }
    public void SetGenericCost(int cost)
    {
        _genericCost = cost;
    }
    public int GetCost()
    {
        return _whiteCost+_blueCost+_blackCost+_redCost+_greenCost+_colorlessCost+_genericCost;
    }
    public int GetWhiteCost()
    {
        return _whiteCost;
    }
    public int GetBlueCost()
    {
        return _blueCost;
    }
    public int GetBlackCost()
    {
        return _blackCost;
    }
    public int GetRedCost()
    {
        return   _redCost;
    }
    public int GetGreenCost()
    {
        return _greenCost;
    }
    public int GetGenericCost()
    {
        return _genericCost;
    }
    public string PrintMana()
    {
        string manaString = "";
        int i = 0;
        if ( _XCost == true)
        {
            manaString += "{X} ";
        }
        manaString += _genericCost +" ";
        for (i = 0; i < _whiteCost; i++)
        {
            manaString += "{W} ";
        }
        for (i = 0; i < _blackCost; i++)
        {
            manaString += "{B} ";
        }
        for (i = 0; i < _blueCost; i++)
        {
            manaString += "{U} ";
        }
        for (i = 0; i < _redCost; i++)
        {
            manaString += "{R} ";
        }
        for (i = 0; i < _greenCost; i++)
        {
            manaString += "{G} ";
        }

        return manaString;
    }
    public void StringToMana(string stringmana)
    {
        string[] cutmana = stringmana.Split(" ");
        if (stringmana.Contains("X")== true)
        {
            _XCost = true;
            _genericCost = int.Parse(cutmana[1]);
        }
        else
        {
            try
            {
                _genericCost = int.Parse(cutmana[0]);
            }
            catch
            {
                _genericCost = 0;
            }
        }
        _whiteCost = stringmana.Split("W").Count()-1;
        _blackCost = stringmana.Split("B").Count()-1;
        _blueCost = stringmana.Split("U").Count()-1;
        _redCost = stringmana.Split("R").Count()-1;
        _greenCost = stringmana.Split("G").Count()-1;
        _whiteCost += stringmana.Split("w").Count()-1;
        _blackCost += stringmana.Split("b").Count()-1;
        _blueCost += stringmana.Split("u").Count()-1;
        _redCost += stringmana.Split("r").Count()-1;
        _greenCost += stringmana.Split("g").Count()-1;
    }
}