import {Express, Request, Response} from 'express';
const app: Express = require('express')();
const PORT: number = 8000;

app.get('/', (req: Request, res: Response) => res.send('Express + TypeScript Server'));


app.listen(PORT, () => {
    console.log(`[server]: Server is running at https://localhost:${PORT}`);
});
