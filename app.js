const task = (name, description, dat, comments) => ({name, description, dat, comments})

const tasks = [
	task('Поход к врачу.', 'Врач хирург.', '05.05.2020', ''),
	task('Позвонить маме.', 'Номер +7(+++)+++++++.', '07.05.2020', ''),
	task('Туса в баре.', 'Бухич.', '10.05.2020', ''),
]


new Vue({
	el: '#app',
	data: {
		tasks: tasks,
		task: tasks[0],
		selectTaskIndex: 0,
		cardVisibility: false
	},
	methods: {
		selectTask: function(index) {
			this.task = tasks[index]
			this.selectTaskIndex = index
		}
	}
})