#include <iostream>
#include <cmath>
#include <vector>

using namespace std;

int main() {
	ios::sync_with_stdio(false);
	cin.tie(0);

	vector<int> f;
	f.push_back(0);
	f.push_back(1);

	int n;
	cin >> n;
	for (int i = 1; i < n; i++) {
		f.push_back(f[i - 1] + f[i]);
	}
	cout << f[f.size()-1];

	return 0;
}
