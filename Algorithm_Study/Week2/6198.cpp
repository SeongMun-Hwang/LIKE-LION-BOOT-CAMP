#include<iostream>
#include<stack>
#include<vector>
using namespace std;

int main() {
	ios_base::sync_with_stdio(false);
	cin.tie(NULL);

	int n;
	cin >> n;
	stack<int> s;
	vector<int> v(n);
	long count = 0;

	for (int i = 0; i < n; i++) {
		cin >> v[i];
	}

	for (int i = 0; i < n; i++) {
		while (!s.empty() && s.top() <= v[i]) {
			s.pop();
		}
		s.push(v[i]);
		count += s.size() - 1;
	}
	
	cout << count;
}