#include<iostream>
#include <vector>
#include<algorithm>
#include<stack>
using namespace std;

int main() {
	ios_base::sync_with_stdio(false);
	cin.tie(NULL);
	int n;
	cin >> n;

	vector<int> v1(n);
	vector<int> v2(n, -1);
	stack<int> s;

	for (int i = 0; i < n; i++) {
		int n;
		cin >> v1[i];
	}
	for (int i = n - 1; i >= 0; i--) {
		while (!s.empty() && v1[i] >= v1[s.top()]) {
			s.pop();
		}
		if (!s.empty()) {
			v2[i] = v1[s.top()];
		}
		s.push(i);
	}
	for (int i = 0; i < n; i++) {
		cout << v2[i] << " ";
	}
}