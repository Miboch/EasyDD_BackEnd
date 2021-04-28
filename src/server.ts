﻿import {Express, Request, Response} from 'express';
import {database} from './infrastructure';
import {environment, loadEnvironment} from './utility';


async function startServer() {
    const app: Express = require('express')();
    const PORT: number = 8000;
    await loadEnvironment('environment.json');
    database.init(environment.connectString);
    app.get('/', (req: Request, res: Response) => res.send('Express + TypeScript Server'));

    app.listen(environment.port, () => {
        console.log(`[server]: Server is running at https://localhost:${environment.port}`);
    });
}

startServer();
