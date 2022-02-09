import mongoose from 'mongoose'
const Schema = mongoose.Schema

export const CoachingSchema = new Schema({
    trainerId: { type: Schema.Types.ObjectId, required: true, ref: 'Account' },
    learnerId: { type: Schema.Types.ObjectId, required: true, ref: 'Account' },
    type: { type: String, enum: ['Aerial', 'Rail', 'Surface', 'Halfpipe'], required: true },
    description: { type: String, required: true },
    payment: { type: Number },
    paymentRecieved: { type: Boolean, default: false },
    totalPrice: { type: Number },
    status: { type: String, enum: ['pending', 'accepted', 'inProgress', 'completed', 'denied', 'canceled'], required: true, default: 'pending' },
}, { timestamps: true, toJSON: { virtuals: true } })

CoachingSchema.virtual('trainer', {
    localField: 'trainerId',
    foreignField: '_id',
    justOne: true,
    ref: 'Account'
})

CoachingSchema.virtual('learner', {
    localField: 'learnerId',
    foreignField: '_id',
    justOne: true,
    ref: 'Account'
})