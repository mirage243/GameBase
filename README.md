````
class Solution {
public:
    vector<string> generateParenthesis(int n) 
    {
        //return solution1(n);
        //return solution2(n);
        return solution3(n);
    }

    //--------------------------------------- solution1 ---------------------------------------

    vector<string> solution1(int n) 
    {
        vector<string> parenthesis;
        string startParenthesis = GetStartParenthes(n);

        parenthesis.push_back(startParenthesis);

        string tempParenthesis = startParenthesis;
        int counter = 0;
        while (std::next_permutation(tempParenthesis.begin(),tempParenthesis.end())) 
        {
            ++counter;
            addElementIfAvailable(parenthesis, tempParenthesis);
        }
        cout << "Counter: " << counter << endl;
        return parenthesis;
    }


    //--------------------------------------- solution2 ---------------------------------------

    vector<string> solution2(int n) {
        vector<string> parenthesis;
        string startParenthesis = GetStartParenthes(n);

        int totalSwipeCount = 0;
        int elementCount = n * 2;

        for (int i = 0; i < elementCount; i++) {
            if (isSwipeNecessary(startParenthesis, i, 1)) {
                string newParenthesis = swipeParanthesis(startParenthesis, i, 1, totalSwipeCount);
                addElementIfAvailable(parenthesis, newParenthesis);

                for (int k = 0; k < elementCount; k++) {
                    if (isSwipeNecessary(newParenthesis, k, 1)) {
                        string updatedParenthesis = swipeParanthesis(newParenthesis, k, 1, totalSwipeCount);
                        addElementIfAvailable(parenthesis, updatedParenthesis);
                    }
                    if (isSwipeNecessary(newParenthesis, k, -1)) {
                        string updatedParenthesis = swipeParanthesis(newParenthesis, k, -1, totalSwipeCount);
                        addElementIfAvailable(parenthesis, updatedParenthesis);
                    }
                }
            }

            if (isSwipeNecessary(startParenthesis, i, -1)) {
                string newParenthesis = swipeParanthesis(startParenthesis, i, -1, totalSwipeCount);
                addElementIfAvailable(parenthesis, newParenthesis);

                for (int k = 0; k < newParenthesis.length(); k++) 
                {
                    if (isSwipeNecessary(newParenthesis, k, 1)) 
                    {
                        string updatedParenthesis = swipeParanthesis(newParenthesis, k, 1, totalSwipeCount);
                        addElementIfAvailable(parenthesis, updatedParenthesis);
                    }
                    if (isSwipeNecessary(newParenthesis, k, -1))
                    {
                        string updatedParenthesis = swipeParanthesis(newParenthesis, k, -1, totalSwipeCount);
                        addElementIfAvailable(parenthesis, updatedParenthesis);
                    }
                }
            }
        }

        cout << "Total Swipe Count: " << totalSwipeCount << endl;

        return parenthesis;
    }

    
    //--------------------------------------- solution3 ---------------------------------------

    vector<string> solution3(int n) 
    {
        vector<string> result;
        string current;
        generateTotalParentheses(current, 0, 0, n, result);
        return result;
    }

    void generateTotalParentheses(string& current, int open, int close, int n, vector<string>& result) 
    {
        if (current.length() == 2 * n) 
        {
            result.push_back(current);
            return;
        }
        
        if (open < n) 
        {
            current.push_back('(');
            generateTotalParentheses(current, open + 1, close, n, result);
            current.pop_back();
        }
        
        if (close < open) 
        {
            current.push_back(')');
            generateTotalParentheses(current, open, close + 1, n, result);
            current.pop_back();
        }
    }

    //------------------------------------------------------------------------------------------

    //-------------------------- UTIL FUNCTIONS ------------------------------------------------

    string GetStartParenthes(int n) 
    {
        string startParenthesis = "";

        for (int i = 0; i < n; i++) 
        {
            startParenthesis += '(';
        }

        for (int i = 0; i < n; i++) 
        {
            startParenthesis += ')';
        }

        return startParenthesis;
    }

    bool isValid(string s) {
        stack<char> st;     // create an empty stack to store opening brackets
        for (char c : s) {  // loop through each character in the string
            if (c == '(') { // if the character is an opening bracket
                st.push(c); // push it onto the stack
            } else {        // if the character is a closing bracket
                if (st.empty() || // if the stack is empty or
                    (c == ')' && st.top() != '(')) {
                    return false; // the string is not valid, so return false
                }
                st.pop(); // otherwise, pop the opening bracket from the stack
            }
        }
        return st.empty();
    }

    void addElementIfAvailable(vector<string>& parenthesis, string parenthes) 
    {
        if (!isContainValue(parenthesis, parenthes) && isValid(parenthes)) 
        {
            parenthesis.push_back(parenthes);
        }
    }

    bool isContainValue(vector<string> parenthesis, string parenthes) 
    {
        return count(parenthesis.begin(), parenthesis.end(), parenthes) > 0;
    }

    string swipeParanthesis(string input, int firstIndex, int swipeAmount, int& totalSwipeCount)
    {
        string temp = input;
        if (firstIndex + swipeAmount < temp.length() && firstIndex + swipeAmount >= 0) 
        {
            char firstChar = temp[firstIndex];
            char secondChar = temp[firstIndex + swipeAmount];

            temp[firstIndex] = secondChar;
            temp[firstIndex + swipeAmount] = firstChar;
            totalSwipeCount++;
        }
        return temp;
    }

    bool isSwipeNecessary(string input, int firstIndex, int swipeAmount) 
    {
        if (firstIndex + swipeAmount < input.length() && firstIndex + swipeAmount >= 0) 
        {
            return input[firstIndex] != input[firstIndex + swipeAmount];
        }
        return false;
    }

    //------------------------------------------------------------------------------------------
};

````
