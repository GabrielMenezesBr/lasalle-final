# App

Here you will find the files to start creating the web application using ReactJS. 

You will find `Dockerfile` and `nginx.conf`, these files should not be changed unless you see the need, study these files they are essential for the application to run in production.

# NodeJS version

I recommend you use in your systema the NodeJS v18.x.x or later.

(NodeJS v18.x.x)[https://nodejs.org/en/download/prebuilt-installer]

# Runing vanilla

to run in development mode you can use the ReactJS Package options.

# Runing using VSCode debug

Go TO > RUN AND DEBUG <  you will have one debug options

- Default: 
    - This option will run the API using your local Node

> In the .vscode/tasks.json file, the environment variables are defined. Therefore, when you run your debug session using VSCode, the application will likely use these environment settings.

```json
"options": {
  "env": {
    "NODE_ENV" : "development"
  }
},
```
# API Provider (Example)

Here you can see an example of an API provider. Please remember that you will be working with two environments. 

```javascript
import axios from 'axios';

const api = axios.create({
    baseUrl: 'https://localhost:7172/api'
});

api.interceptors.request.use((config) => {
    const token = localStorage.getItem('token');
    if(token){
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
});

export default api;

```

Take care to configure the provider to understand both environments correctly. I suggest you try using enviroonment variable like:

```javascript
var baseUrl = process.env.NODE_ENV === 'production' ? '/api' : 'https://localhost:7172/api'
```

The Dockerfile, used in Production, already defined the `NODE_ENV = Production`;