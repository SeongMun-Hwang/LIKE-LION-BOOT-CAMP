#include <iostream>
#include <vector>
#include <algorithm>
#include <cmath>

using namespace std;

int main() {
    int n;
    cin >> n;

    long long num = 5;
    for (int i = 2; i <= n; i++) {
        num = num + ((i + 1) * 3 - 2);
    }
    cout << num % 45678;
    return 0;
}