#include<iostream>
#include <vector>
using namespace std;

int main() {
	int n;
	cin >> n;

	vector<int> vector;

	for (int i = 0; i < n; i++) {
		int a;
		cin >> a;

		if (vector.empty()) {
			vector.push_back(a);
		}
		else {
			bool inserted = false;
			for (int j = 0; j < vector.size(); j++) {
				if (vector[j] == a) {
					inserted = true;
					break;
				}
				else if (vector[j] > a) {
					vector.insert(vector.begin()+j, a);
					inserted = true;
					break;
				}				
			}
			if (!inserted) {
				vector.push_back(a);
			}
		}
	}

	for (int i = 0; i < vector.size(); i++) {
		cout << vector[i] << " ";
	}
	
	return 0;
}