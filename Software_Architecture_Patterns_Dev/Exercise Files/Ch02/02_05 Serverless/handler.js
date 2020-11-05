'use strict';

const aws = require('aws-sdk');

module.exports.main = async event => {
  console.log(`Sending booking notification for: ${JSON.stringify(event.body)}`);
  const sqs = new aws.SQS();
  await sqs.sendMessage({
    QueueUrl: `https://sqs.eu-west-1.amazonaws.com/950772974287/BookingQueue`,
    MessageBody: JSON.stringify(event.body)
  }).promise();

  console.log('Message sent');

  return {
    statusCode: 200,
    body: JSON.stringify(
      {
        message: 'Booking processed',
        input: event.body,
      },
      null,
      2
    ),
  };
};
