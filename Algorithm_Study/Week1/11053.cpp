#include<iostream>
#include <vector>
#include<algorithm>
using namespace std;

int main() {
	int n;
	cin >> n;

	vector<int> v;

	for (int i = 0; i < n; i++) {
		int a;
		cin >> a;
		v.push_back(a);
	}

	vector<int> vList(n, 1);
	for (int i = 1; i < n; i++) {
		for (int j = 0; j < i; j++) {
			if (v[i] > v[j]) {
				vList[i] = max(vList[i], vList[j] + 1);
			}
		}
	}

	cout << *max_element(vList.begin(), vList.end());

	return 0;
}