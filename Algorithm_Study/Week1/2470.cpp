#include <iostream>
#include <vector>
#include <algorithm>
#include <cmath>

using namespace std;

int main() {
    int n;
    cin >> n;

    vector<int> solutions(n);
    for (int i = 0; i < n; ++i) {
        cin >> solutions[i];
    }

    sort(solutions.begin(), solutions.end());

    int left = 0;
    int right = n - 1;
    int closest_sum = 2e9 + 1;
    int sol1 = solutions[left];
    int sol2 = solutions[right];

    while (left < right) {
        int sum = solutions[left] + solutions[right];

        if (abs(sum) < abs(closest_sum)) {
            closest_sum = sum;
            sol1 = solutions[left];
            sol2 = solutions[right];
        }
        if (sum < 0) {
            ++left;
        }
        else {
            --right;
        }
    }
    cout << sol1 << " " << sol2 << endl;
    return 0;
}