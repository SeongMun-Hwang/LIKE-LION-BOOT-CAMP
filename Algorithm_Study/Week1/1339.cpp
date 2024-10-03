#include <iostream>
#include <vector>
#include <string>
#include <algorithm>
using namespace std;

int main() {
    int N;
    cin >> N;
    
    vector<string> words(N);
    int alpha_value[26] = {0};

    // 단어 입력
    for (int i = 0; i < N; ++i) {
        cin >> words[i];
    }

    for (const string& word : words) {
        int power = 1;
        for (int i = word.size() - 1; i >= 0; --i) { 
            alpha_value[word[i] - 'A'] += power;
            power *= 10;
        }
    }

    vector<int> values;
    for (int i = 0; i < 26; ++i) {
        if (alpha_value[i] > 0) {
            values.push_back(alpha_value[i]);
        }
    }
    sort(values.rbegin(), values.rend()); 

    int number = 9, result = 0;
    for (int value : values) {
        result += value * number;
        --number;
    }

    cout << result << endl;
    return 0;
}