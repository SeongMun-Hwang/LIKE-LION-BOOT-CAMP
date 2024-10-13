#include <iostream>
#include <cmath>
#include <vector>

using namespace std;

int main() {
	ios::sync_with_stdio(false);
	cin.tie(0);

	int n;
	cin >> n;
	for (int i = 0; i < n; i++) {
		int k, n;
		cin >> k >> n;

		vector<vector<int>> apart(k + 1, vector<int>(n + 1, 0));
		for (int j = 1; j <= n; j++) {
			apart[0][j] = j;
		}
		for (int a = 1; a <= k; a++) {
			for (int b = 1; b <= n; b++) {
				apart[a][b] = apart[a][b - 1] + apart[a - 1][b];
			}
		}
		cout << apart[k][n] <<"\n";
	}
	return 0;
}
