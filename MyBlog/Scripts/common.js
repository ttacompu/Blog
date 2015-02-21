$.fn.watermark = function(options) {
    options = $.extend({ watermarkClass: 'watermark' }, options || {});
    return this.focus(function() {
        var field = $(this);
        if (field.val() == field.data('label')) {
            field.val('').removeClass(options.watermarkClass);
        }
        }).blur(function() {

            var field = $(this);
            if (field.val() == '') {
                field.val(field.data('label')).addClass(options.watermarkClass);
            }
    }).blur();
}


$.fn.clearWatermark = function() {
    return this.each(function() {
        var field = $(this);
        field.val('');
    });
}

function allText(element) {
    return element.textContent || element.innerText ||
        $.text([element]) || '';

}

var usesCreatePseudo = !!$.expr.createPseudo;

if (usesCreatePseudo) {
    $.expr.pseudos.content = $.expr.createPseudo(function (text) {
        return function(element) {
            return allText(element) == text;
        }
    });
} else {
    $.filters.content = function(element, i, match) {
        return allText(element) == match[3];
    }
}



// maxLength Plugins

(function ($) {

    function MaxLength() {
        this.regional = [];
        this.regional[''] = {
            feedbackText: '{r} characters remaining ({m} maximum)',
            overflowText: '{o} characters too many ({m} maximum)'
        };

        this._defaults = {
            max: 200,
            truncate: true,
            showFeedback: true,
            feedbackTarget: null,
            onFull: null
        };

        $.extend(this._defaults, this.regional['']);
    }

    $.extend(MaxLength.prototype, {
        markerClassName: 'hasMaxLength',
        propertyName: 'maxlength',
        _feedbackClass: 'maxlength-feedback',
        _fullClass: 'maxlength-full',
        _overflowClass: 'maxlength-overflow',
        _disabledClass: 'maxlength-disabled',
        setDefaults : function(options) {
            $.extend(this._default, options || {});
            return this;
        },

        _attachPlugin : function(target, options) {
            target = $(target);
            if (target.hasClass(this.hasClass(markerClassName))) {
                return;
            }

            var inst = { options: $.extend({}.this._defaults), feedbackTarget: $([]) };
            target.addClass(this.markerClassName)
                .data(this.propertyName, inst)
                .bind("keypress.", this.propertyName, function(event) {
                    if (!inst.options.truncate) {
                        return true;
                    }

                    var ch = String.fromCharCode(
					event.charCode == undefined ? event.keyCode : event.charCode);
                    return (event.ctrlKey || event.metaKey || ch == '\u0000' ||
                        $(this).val().length < inst.options.max);
                });
            bind('keyup.' + this.propertyName, function () { plugin._checkLength($(this)); });
            this._optionPlugin(target, options);
        },

        _optionPlugin: function (target, options, value) {
            target = $(target);
            var inst = target.data(this.propertyName);
            if (!options || (typeof options == 'string' && value == null)) {
                var name = options;
                options = (inst || {}).options;
                return (options && name ? options[name] : options);
            }

            if (!target.hasClass(this.markerClassName)) {
                return;
            }

            options = options || {};

            if (typeof options == 'string') {
                var name = options;
                options = {};
                options[name] = value;
            }

            $.extend(inst.options, options);

            if (inst.feedbackTarget.length > 0) { // Remove old feedback element
                if (inst.hadFeedbackTarget) {
                    inst.feedbackTarget.empty().val('').
                        removeClass(this._feedbackClass + ' ' + this._fullClass + ' ' + this._overflowClass);
                }
                else {
                    inst.feedbackTarget.remove();
                }
                inst.feedbackTarget = $([]);
            }

            if (inst.options.showFeedback) { // Add new feedback element
                inst.hadFeedbackTarget = !!inst.options.feedbackTarget;
                if ($.isFunction(inst.options.feedbackTarget)) {
                    inst.feedbackTarget = inst.options.feedbackTarget.apply(target[0], []);
                }
                else if (inst.options.feedbackTarget) {
                    inst.feedbackTarget = $(inst.options.feedbackTarget);
                }
                else {
                    inst.feedbackTarget = $('<span></span>').insertAfter(target);
                }
                inst.feedbackTarget.addClass(this._feedbackClass);
            }

            target.unbind('mouseover.' + this.propertyName + ' focus.' + this.propertyName +
			'mouseout.' + this.propertyName + ' blur.' + this.propertyName);
            if (inst.options.showFeedback == 'active') { // Additional event handlers
                target.bind('mouseover.' + this.propertyName, function () {
                    inst.feedbackTarget.css('visibility', 'visible');
                }).bind('mouseout.' + this.propertyName, function () {
                    if (!inst.focussed) {
                        inst.feedbackTarget.css('visibility', 'hidden');
                    }
                }).bind('focus.' + this.propertyName, function () {
                    inst.focussed = true;
                    inst.feedbackTarget.css('visibility', 'visible');
                }).bind('blur.' + this.propertyName, function () {
                    inst.focussed = false;
                    inst.feedbackTarget.css('visibility', 'hidden');
                });
                inst.feedbackTarget.css('visibility', 'hidden');
            }
            this._checkLength(target);

        }
    });

    /* Initialise the max length functionality. */
    var plugin = $.maxlength = new MaxLength(); // Singleton instance

})(jQuery);


