#include<iostream>
using namespace std;

int main() {
	int N, M;
	cin >> N >> M;

	char** arr = new char* [N];

	for (int i = 0; i < N; i++) {
		arr[i] = new char[M];
	}

	for (int i = 0; i < N; i++) {
		for (int j = 0; j < M; j++) {
			cin >> arr[i][j];
		}
	}

	for (int i = 0; i < N; i++) {
		for (int j = 0; j < M; j++) {
			if (arr[i][j] != '.') {
				arr[i][M - 1 - j] = arr[i][j];
			}
		}
	}

	for (int i = 0; i < N; i++) {
		for (int j = 0; j < M; j++) {
			cout << arr[i][j];
		}
		cout << "\n";
	}
	return 0;
}