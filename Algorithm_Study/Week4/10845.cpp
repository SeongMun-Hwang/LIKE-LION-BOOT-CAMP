#include<iostream>
#include <queue>
#include<algorithm>
#include<cmath>
#include<climits>
using namespace std;

int main() {
	ios_base::sync_with_stdio(false);
	cin.tie(NULL);

	queue<int> q;
	int n;
	cin >> n;

	while (n > 0) {
		string str;
		cin >> str;

		if (str == "push") {
			int n;
			cin >> n;
			q.push(n);
		}
		else if (str == "pop") {
			if (q.empty()) cout << -1 << "\n";
			else {
				cout << q.front() << "\n";
				q.pop();
			}
		}
		else if (str == "size") {
			cout << q.size() << "\n";
		}
		else if (str == "empty") {
			if (q.empty()) cout << "1" << "\n";
			else cout << "0" << "\n";
		}
		else if (str == "front") {
			if (q.empty()) cout << "-1" << "\n";
			else cout << q.front() << "\n";
		}
		else if (str == "back") {
			if (q.empty()) cout << "-1" << "\n";
			else cout << q.back() << "\n";
		}
		n--;
	}
	
}