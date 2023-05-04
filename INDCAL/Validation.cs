class Validation
{
    public static readonly Dictionary<string,int> Elements = new Dictionary<string, int>()
    {
            {"H",1},{"He",2},{"Li",1},{"Be",2},{"B",3},{"C",4},{"N",5},
	        {"O",6},{"F",7},{"Ne",8},{"Na",1},{"Mg",2},{"Al",3},{"Si",5},
            {"P",5},{"S",6},{"Cl",7},{"Ar",8},{"K",1},{"Ca",2},{"Sc",3},
            {"Ti",4},{"V",5},{"Cr",6},{"Mn",7},{"Fe",8},{"Co",9},{"Ni",10},
            {"Cu",11},{"Zn",12},{"Ga",3},{"Ge",3},{"As",5},{"Se",6},{"Br",7},
            {"Kr",8},{"Rb",1},{"Sr",2},{"Y",3},{"Zr",4},{"Nb",5},{"Mo",6},
            {"Tc",7},{"Ru",8},{"Rh",9},{"Pd",10},{"Ag",11},{"Cd",12},{"In",3},
            {"Sn",4},{"Sb",5},{"Te",6},{"I",10},{"Xe",8},{"Cs",1},{"Ba",2},
            {"La",3},{"Ce",4},{"Pr",5},{"Nd",6},{"Pm",7},{"Sm",8},{"Eu",9},
            {"Gd",10},{"Tb",11},{"Dy",12},{"Ho",13},{"Er",14},{"Tm",15},{"Yb",16},
            {"Lu",3},{"Hf",4},{"Ta",5},{"W",6},{"Re",7},{"Os",8},{"Ir",9},
            {"Pt",10},{"Au",11},{"Hg",12},{"Pb",4},{"Bi",5},{"Po",6},
            {"At",7},{"Rn",8},{"Fr",1},{"Ra",2},{"Ac",3},{"Th",4},{"Pa",5},
            {"U",6},{"Np",7},{"Pu",8},{"Am",9},{"Cm",10},{"Bk",11},{"Cf",12},
            {"Es",13},{"Fm",14},{"Md",15},{"No",16},{"Lr",3},{"Rf",4},{"Db",5},
            {"Sg",6},{"Bh",7},{"Hs",8},{"Mt",9},{"Ds",10},{"Rg",11},{"Cn",12},
            {"Nh",3},{"Fl",4},{"Mc",5},{"Lv",6},{"Ts",7},{"Og",8}
    };

    public static readonly Dictionary<char,int> bonds = new Dictionary<char, int>()
    {
        {'-',1},{'=',2},{'#',3},{'$', 4},{'.', 0},{':',1}
    };

    public bool isValid(string input)
    {
        char[] res = input.ToCharArray();
        bool isRing=false,isBranch=false,ValidRing=true,ValidBranch=true;
        for(int i=0;i<res.Length;i++)
        {
            if(char.IsDigit(res[i])) isRing=true;
            if(res[i]=='(' || res[i]==')') isBranch=true;
        }

        if(isRing) ValidRing = checkRingValidity(res);
        if(isBranch) ValidBranch = checkBranchValidity(res);

        return (ValidRing && ValidBranch && (checkElementValidity(res)));
    }

    public bool checkRingValidity(char[] res)
    {
        int count=0;
        for(int i=0;i<res.Length;i++) if(char.IsDigit(res[i])) count++;
        return count%2==0;
    }

    public bool checkBranchValidity(char[] res)
    {
        int count=0;
        for(int i=0;i<res.Length;i++)
        {
            if(res[i]=='(') count++;
            if(res[i]==')') count--;
        }
        return count==0;
    }

    public bool checkElementValidity(char[] res)
    {
        for(int i=0;i<res.Length-1;i++)
        {
            if(Elements.ContainsKey(char.ToString(res[i])) || Elements.ContainsKey(char.ToString(res[i])+char.ToString(res[i+1])) || bonds.ContainsKey(res[i]))  continue;
            else if(char.IsLower(res[i]) || res[i] =='(' || res[i]==')' || char.IsDigit(res[i])) continue;
            else return false; 
        }
        if(char.IsLower(res[res.Length-1]) || res[res.Length-1] =='(' || res[res.Length-1]==')' || char.IsDigit(res[res.Length-1]) || Elements.ContainsKey(char.ToString(res[res.Length-1]))) return true;
        else return false;
    }
}