-- SQLite
SELECT s.Name, su.StockId, SUM(Amount)
FROM StockUnits su, Stocks s
WHERE su.StockId = s.Id
GROUP BY su.StockId
ORDER BY SUM(su.StockId) DESC;