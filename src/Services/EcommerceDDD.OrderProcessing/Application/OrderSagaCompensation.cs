﻿namespace EcommerceDDD.OrderProcessing.Application;

/// <summary>
/// Handles compensation events for OrderSaga
/// </summary>
public class OrderSagaCompensation(
	ICommandBus commandBus
) :	IEventHandler<PaymentFailed>,
	IEventHandler<CustomerReachedCreditLimit>,
	IEventHandler<ShipmentFailed>,
	IEventHandler<ProductWasOutOfStock>,
	IEventHandler<OrderCanceled>
{
	private readonly ICommandBus _commandBus = commandBus;

	public Task HandleAsync(PaymentFailed @integrationEvent,
		CancellationToken cancellationToken)
	{
		// Payment failed due to issues
		var command = CancelOrder.Create(
			OrderId.Of(@integrationEvent.OrderId),
			OrderCancellationReason.PaymentFailed);

		return _commandBus.SendAsync(command, cancellationToken);
	}

	public async Task HandleAsync(CustomerReachedCreditLimit @integrationEvent,
		CancellationToken cancellationToken)
	{
		// Payment failed due to credit limit
		var command = CancelOrder.Create(
			OrderId.Of(@integrationEvent.OrderId),
			OrderCancellationReason.CustomerReachedCreditLimit);

		await _commandBus.SendAsync(command, cancellationToken);
	}

	public Task HandleAsync(ShipmentFailed @integrationEvent,
		CancellationToken cancellationToken)
	{
		// Shipment failed due to issues
		var command = CancelOrder.Create(
			OrderId.Of(@integrationEvent.OrderId),
			OrderCancellationReason.ShipmentFailed);

		return _commandBus.SendAsync(command, cancellationToken);
	}

	public async Task HandleAsync(ProductWasOutOfStock @integrationEvent,
		CancellationToken cancellationToken)
	{
		// Product was out of stock when shipping 
		var command = CancelOrder.Create(
			OrderId.Of(@integrationEvent.OrderId),
			OrderCancellationReason.ProductWasOutOfStock);

		await _commandBus.SendAsync(command, cancellationToken);
	}

	public async Task HandleAsync(OrderCanceled @integrationEvent,
		CancellationToken cancellationToken)
	{
		if (@integrationEvent.PaymentId.HasValue) // if order was paid but canceled by user
		{
			var command = RequestCancelPayment.Create(
				PaymentId.Of(@integrationEvent.PaymentId!.Value),
				PaymentCancellationReason.OrderCanceled);

			await _commandBus.SendAsync(command, cancellationToken);
		}
	}
}