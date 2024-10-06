#include <iostream>
#include <vector>
#include <algorithm>
#include <cmath>

using namespace std;

int main() {
	ios::sync_with_stdio(false);
	cin.tie(0);

	int n, m;
	cin >> n >> m;
	int* v = new int[n + 1] {0};

	for (int i = 1; i <= n; i++) {
		int a;
		cin >> a;
		v[i] = v[i - 1] + a;

	}
	for (int i = 0; i < m; i++) {
		int a, b;
		cin >> a >> b;
		
		cout << v[b] - v[a-1] << "\n";
		
	}
	return 0;
}