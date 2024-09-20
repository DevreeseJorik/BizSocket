import socket

HOST = '127.0.0.1'
PORT = 12345

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as server_socket:
    server_socket.bind((HOST, PORT))
    server_socket.listen()
    print(f"Server listening on {HOST}:{PORT}")
    while True:
        try:
            client_socket, address = server_socket.accept()
            print(f"Connection from {address}")

            with client_socket:
                while True:
                    data = client_socket.recv(1024)
                    if not data:
                        break
                
                    print(f"Received from client: {data.decode()}")
                    message = f"Response from server: {data.decode()}"
                    client_socket.sendall(message.encode())
        except Exception as e:
            print(f"Error: {e}")
            continue
