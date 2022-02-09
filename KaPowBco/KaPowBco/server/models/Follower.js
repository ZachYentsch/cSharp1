import mongoose from 'mongoose'
const Schema = mongoose.Schema

export const FollowerSchema = new Schema({
    trainerId: { type: Schema.Types.ObjectId, required: true, ref: 'Account' },
    learnerId: { type: Schema.Types.ObjectId, required: true, ref: 'Account' }
},
    { timestamps: true, toJSON: { virtuals: true } })

FollowerSchema.virtual('trainer', {
    localField: 'trainerId',
    foreignField: '_id',
    justOne: true,
    ref: 'Account',
})

FollowerSchema.virtual('learner', {
    localField: 'learnerId',
    foreignField: '_id',
    justOne: true,
    ref: 'Account'

})