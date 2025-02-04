app.post('/process-payment', function (req, res, next) {
    var CCNumber = req.body.cc
    var expDate = req.body.expDate
    var CVV = req.body.CVV
    var orderNumber = req.body.orderNumber
    var success = processPayment(CCNumber, expDate, CVV, orderNumber)
    log("payment", success, JSON.stringify(req.body))
  })